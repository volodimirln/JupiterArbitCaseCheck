import React, { Component } from 'react';
import { Table, Pagination, Button, Form } from 'react-bootstrap';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import UserService from '../services/user.service';
import AuthService from "../services/auth.service";
import { Navigate } from "react-router-dom";
import  "../App.css";
class CasesTable extends Component {
  constructor(props) {
    super(props);

    this.state = {
      redirect: null,
      userReady: false,
      cases: [],
      filteredCases: [],
      currentPage: 1,
      casesPerPage: 10,
      sortField: null,
      cities: [],
      sortOrder: null,
      countCases: 10,
      WASM: '',
      cityCases: '',
      datefromCases: '',
      datetoCases: '',
      searchCases: '',
      hiddenCases: false,
      currentUser: {
        id: 0,
        name: "",
        surname: "",
        patronymic: "",
        email: "",
        phone: "",
        roleId: 0,
        dateRegistration: "",
        dataChange: "",
        role: null
    }
    };
  }

  componentDidMount() {
    //this.fetchData(10, "", "", "", "", "");
    const currentUser = AuthService.getCurrentUserWeb()
    if (localStorage.getItem("user")  === null){
       this.setState({ redirect: "/home" });
    }else{
    AuthService.getCurrentUserWeb().then(
      response => {
        this.setState({
          currentUser: response.data
        });
      }
    );
    UserService.getCourtes().then(response => {this.setState({cities: response.data})})
    this.setState({ currentUser: currentUser, userReady: true })
  }
  }

  fetchData(count, city,  datefrom,dateto, search, wasm) {
    var res =  UserService.getCases(count, city, dateto, datefrom, search, wasm)
      .then(response => {
        if(response.data.length > 0){
          this.setState({ cases: response.data, filteredCases: response.data, userReady: true });
          return response.data;
        }else{
          alert("Данные по делам не найдены");
        }
      });
      if(res != null){
        //this.setState({ cases: res, filteredCases: res, userReady: true });
      }
      res.then(response=>{
        console.log(response.data)
    });
  }
  fetchFavoriteData() {
    UserService.getFavoriteCases()
      .then(response => {
        this.setState({ cases: response.data, filteredCases: response.data, userReady: true });
      })
      .catch(error => {
        console.error('Ошибка при загрузке данных:', error);
      });
  }

  changePage = (pageNumber) => {
    this.setState({ currentPage: pageNumber });
  }

  sortCases = (field) => {
    const { sortField, sortOrder, filteredCases } = this.state;
    let order = 'asc';
    if (field === sortField && sortOrder === 'asc') {
      order = 'desc';
    }

    const sortedCases = filteredCases.sort((a, b) => {
      if (a[field] < b[field]) {
        return order === 'asc' ? -1 : 1;
      }
      if (a[field] > b[field]) {
        return order === 'asc' ? 1 : -1;
      }
      return 0;
    });

    this.setState({ filteredCases: sortedCases, sortField: field, sortOrder: order });
  }

  handleCountCases = (event) => {
    const query = event.target.value;
    this.setState({ countCases: query });
  }


  refreshData = () => {
    this.setState({ userReady: false });
    this.fetchData();
  }
  
  handleSaveCount = () => {
    const { countCases, cityCases, datefromCases, datetoCases, searchCases, WASM} = this.state;
    this.setState({ countCases: countCases, cityCases: cityCases, datefromCases: datefromCases, datetoCases: datetoCases, searchCases: searchCases, WASM: WASM });
    this.fetchData(countCases, cityCases, datefromCases, datetoCases, searchCases, WASM);
  }

  handleCityCases = (event) => {
    const query = event.target.value;
    this.setState({ cityCases: query });
  }
  handleSaveCity = () => {
    const { countCases, cityCases, datefromCases, datetoCases, searchCases, WASM} = this.state;
    this.setState({ countCases: countCases, cityCases: cityCases, datefromCases: datefromCases, datetoCases: datetoCases, searchCases: searchCases, WASM: WASM });
    if(WASM != ""){
      this.fetchData(countCases, cityCases, datefromCases, datetoCases, searchCases, WASM);
    }else{
      alert("Добавьте ключ");
    }
  }

  handleDateFromCases = (date) => {
    this.setState({ datefromCases: date.toISOString().split('T')[0]  });
  }

  handleSaveDateFrom = () => {
    const { countCases, cityCases, datefromCases, datetoCases, searchCases, WASM } = this.state;
    this.setState({ countCases: countCases, cityCases: cityCases, datefromCases: datefromCases, datetoCases: datetoCases, searchCases: searchCases, WASM: WASM });
    this.fetchData(countCases, cityCases, datefromCases, datetoCases, searchCases, WASM);
  }
  handleDateToCases = (date) => {
    this.setState({ datetoCases: date.toISOString().split('T')[0] });
  }

  handleDateToFrom = () => {
    const { countCases, cityCases, datefromCases, datetoCases, searchCases, WASM } = this.state;
    this.setState({ countCases: countCases, cityCases: cityCases, datefromCases: datefromCases, datetoCases: datetoCases, searchCases: searchCases, WASM: WASM  });
    this.fetchData(countCases, cityCases, datefromCases, datetoCases, searchCases, WASM);
  }

  handleSearchCases = (event) => {
    const query = event.target.value;
    this.setState({ searchCases: query });
  }

  handleSaveWASM = () => {
    const { countCases, cityCases, datefromCases, datetoCases, searchCases, WASM } = this.state;
    this.setState({ countCases: countCases, cityCases: cityCases, datefromCases: datefromCases, datetoCases: datetoCases, searchCases: searchCases, WASM: WASM });
    if(cityCases == ""){
      alert("Выберете город");
    }
    this.fetchData(countCases, cityCases, datefromCases, datetoCases, searchCases, WASM);
  }
  handleWASM= (event) => {
    const query = event.target.value;
    this.setState({ WASM: query });
  }
  openInNewTab = (url) => {
    const newWindow = window.open(url, '_blank', 'noopener,noreferrer')
    if (newWindow) newWindow.opener = null
  }
  handleFavoriteCases = () => {
    this.setState({ hiddenCases: true });
    this.fetchFavoriteData();
  }
  handleSaveFavoriteCases = (item) => {
    console.log(item);
    UserService.getAddFavoriteCases(item);
    alert("Дело "+ item.CaseNumber +" сохранено в Избранном");
  }
  handleDelFavoriteCases = (item) => {
   UserService.getDelFavoriteCases(item.Id);
   alert("Дело "+ item.CaseNumber +" удалено из Избранного");

  }
  handleSearch = () => {
    const { countCases, cityCases, datefromCases, datetoCases, searchCases, WASM } = this.state;
    this.setState({ countCases: countCases, cityCases: cityCases, datefromCases: datefromCases, datetoCases: datetoCases, searchCases: searchCases, WASM: WASM, hiddenCases: false});
    this.fetchData(countCases, cityCases, datefromCases, datetoCases, searchCases, WASM);
  }


  renderPagination() {
    const { casesPerPage, filteredCases, currentPage } = this.state;
    const pageNumbers = [];

    for (let i = 1; i <= Math.ceil(filteredCases.length / casesPerPage); i++) {
      pageNumbers.push(i);
    }

    return (
      <Pagination>
        {pageNumbers.map(number => (
          <Pagination.Item key={number} active={number === currentPage} onClick={() => this.changePage(number)}>
            {number}
          </Pagination.Item>
        ))}
      </Pagination>
    );
  }

  render() {
    if (this.state.redirect) {
      return <Navigate to={this.state.redirect} />
    }
    const { filteredCases, userReady, currentPage, casesPerPage, countCases, cityCases, datetoCases, datefromCases, searchCases, cities, WASM, hiddenCases } = this.state;
    
    if (!userReady) {
      return <div>Загрузка данных...</div>;
    }

    // Calculate current cases
    const indexOfLastCase = currentPage * casesPerPage;
    const indexOfFirstCase = indexOfLastCase - casesPerPage;
    const currentCases = filteredCases.slice(indexOfFirstCase, indexOfLastCase);

    return (
      <div>
        {!hiddenCases && <div>
                  <h1>Арбитражные дела</h1>
                  </div>}
                  {hiddenCases && <div>
                    <h1>Избранные дела</h1>
                 </div>}
        <div class="container">
  <div class="row">
    <div class="col-6">
       <Form.Control
          type="text"  as="select" style={{marginBottom: "10px"}} placeholder="Город" value={cityCases} onChange={this.handleCityCases}
        >
           <option value="">Выберите город</option>
        {cities.map(city => (
          <option value={city.name}>{city.court}</option>
        ))}
        </Form.Control>
        <Button variant="info" style={{marginBottom: "20px", background: "#9370D8", border: "none", width: "100%", height: "30px", padding: "1px", fontSize: "11pt"}} onClick={this.handleSaveCity}>Город</Button>
        <DatePicker
    
    selected={datefromCases}
    onChange={this.handleDateFromCases}
    dateFormat="yyyy-MM-dd"
    placeholderText="Дата с"
    style={{ marginBottom: "10px", with: "100%" }}
  />
          <Button variant="info" style={{marginBottom: "20px", background: "#9370D8", border: "none", width: "100%", height: "30px", padding: "1px", fontSize: "11pt"}} onClick={this.handleDateToCases}>Дата с</Button>
        <Form.Control
          type="text" style={{marginBottom: "10px"}} placeholder="Ключ" value={WASM} onChange={this.handleWASM}
        />
        <Button variant="info" style={{marginBottom: "20px", background: "#9370D8", border: "none", width: "100%", height: "30px", padding: "1px", fontSize: "11pt"}} onClick={this.handleSaveWASM}>Ключ</Button>

    </div>
    <div class="col-6">
    <DatePicker
    
                selected={datetoCases}
                onChange={this.handleDateToCases}
                dateFormat="yyyy-MM-dd"
                placeholderText="Дата до"
                style={{ marginBottom: "10px", with: "100%" }}
              />
        <Button variant="info" style={{marginBottom: "20px" , background: "#9370D8", border: "none", width: "100%", height: "30px", padding: "1px", fontSize: "11pt"}} onClick={this.handleDateToFrom}>Дата до</Button>
        <Form.Control
          type="text" style={{marginBottom: "10px"}} placeholder="Поиск" value={searchCases} onChange={this.handleSearchCases}
        />
        <Button variant="info" style={{marginBottom: "20px" , background: "#9370D8", border: "none", width: "100%", height: "30px", padding: "1px", fontSize: "11pt"}} onClick={this.handleSearch}>Поиск</Button>

        <Button variant="info" style={{marginBottom: "20px" , background: "#9370D8", border: "none", width: "100%", height: "30px", padding: "1px", fontSize: "11pt"}} onClick={this.handleFavoriteCases}>Избранные</Button>
        <Button variant="info" style={{marginBottom: "20px" , background: "#9370D8", border: "none", width: "100%", height: "30px", padding: "1px", fontSize: "11pt"}} onClick={this.handleSearch}>Все</Button>

    </div>
  </div>
</div>
        
        
        <Table striped bordered hover>
          <thead>
            <tr>
              <th onClick={() => this.sortCases('id')}>#</th>
              <th onClick={() => this.sortCases('Date')}>Дата</th>
              <th onClick={() => this.sortCases('CaseNumber')}>Номер дела</th>
              <th onClick={() => this.sortCases('Plaintiff')}>Истец</th>
              <th onClick={() => this.sortCases('Respondent')}>Ответчик</th>
              <th onClick={() => this.sortCases('Court')}>Суд</th>
              <th onClick={() => this.sortCases('Court')}>Судья</th>
              <th></th>
              <th></th>
              </tr>
          </thead>
          <tbody>

            
            {currentCases.map((caseItem, index) => (
              <tr key={index}>
                <td>{indexOfFirstCase + index + 1}</td> 
                <td>{caseItem.Date}</td>
                <td>{caseItem.CaseNumber}</td> 
                <td>{caseItem.Plaintiff}</td>
                <td>{caseItem.Respondent}</td>
                <td>{caseItem.Court}</td>
                <td>{caseItem.Judge}</td>
                <td><button style={{marginBottom: "20px", borderRadius: "5px", width:"100px", background: "#2196F3",color: "#fff", margin: "", border: "none", height: "30px", padding: "1px", fontSize: "11pt"}}  onClick={() => this.openInNewTab(caseItem.СaseLink)}>Открыть</button></td>
                <td>
                  <div>
                  {!hiddenCases && <div>
                  <button style={{marginBottom: "20px", borderRadius: "5px", width:"100px", background: "#00C853",color: "#fff", margin: "", border: "none", height: "30px", padding: "1px", fontSize: "11pt"}} onClick={(e) => this.handleSaveFavoriteCases(caseItem)}>Сохранить</button>
                  </div>}
                  {hiddenCases && <div>
                 <button style={{marginBottom: "20px", borderRadius: "5px", width:"100px", background: "#FF3D00",color: "#fff", margin: "", border: "none", height: "30px", padding: "1px", fontSize: "11pt"}} onClick={(e) => this.handleDelFavoriteCases(caseItem)}>Удалить</button>
                 </div>}
                 </div>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
        {this.renderPagination()}
      </div>
    );
  }
}

export default CasesTable;