import axios from "axios";

const API_URL = "http://127.110.110.33:7000/auth/";

class AuthService {
  login(username, password) {
    return axios
      .post(API_URL + "login", {
        username,
        password
      })
      .then(response => {
          localStorage.setItem("user", JSON.stringify(response.data));        
        return response.data;
      });
  }



  getCurrentUserWeb() {
   return axios
      .post(API_URL + "userinfo", "", {
      headers: {
        'Authorization': "Bearer " +   localStorage.getItem("user").replace('"','').replace('"','')
    }
  })
  }




  logout() {
    localStorage.removeItem("user");
  }

  register(name, surname, patronymic, email, phone) {
    return axios.post(API_URL + "signup", {
      name,
      surname,
      patronymic,
      email,
      phone
    }, {
      headers: {
        'Authorization': "Bearer " +   localStorage.getItem("user").replace('"','').replace('"','')
    }
  });
  }


  password(userId, hashPassword, status) {
    return axios.patch("http://127.110.110.33:7000/passwordChange", {
      userId,
      hashPassword,
      status
    }, {
      headers: {
        'Authorization': "Bearer " +   localStorage.getItem("user").replace('"','').replace('"','')
    }
  }).then(response => {
    alert("Пользователь зарегистрирован");
});
  }

  getCurrentUser() {
    return JSON.parse(localStorage.getItem('user'));;
  }
}

export default new AuthService();
