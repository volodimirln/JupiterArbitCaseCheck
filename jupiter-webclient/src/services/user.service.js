import axios from 'axios';
import authHeader from './auth-header';

const API_URL = 'http://127.110.110.33:7000/';

class UserService {
  getPublicContent() {
    return axios.get(API_URL + 'all');
  }

  getUserBoard() {
    return axios.get(API_URL + 'user', { headers: authHeader() });
  }

  getModeratorBoard() {
    return axios.get(API_URL + 'mod', { headers: authHeader() });
  }

  getAdminBoard() {
    return axios.get(API_URL + 'admin', { headers: authHeader() });
  }

  getCourtes() {
    return axios
       .post(API_URL + "courts", "", {
       headers: {
         'Authorization': "Bearer " +   localStorage.getItem("user").replace('"','').replace('"','')
     }
   })
   }

  getCases(count, city, datefrom, dateto, search, wasm) {
    //console.log(API_URL + 'arbitcase?count='+count+'&city='+city+"&datefrom="+dateto+"&dateto="+datefrom+"&search="+search+"&wasm="+wasm);
    return axios
       .post(API_URL + 'arbitcase?count='+count+'&city='+city+"&datefrom="+dateto+"&dateto="+datefrom+"&search="+search+"&wasm="+wasm, "", {
       headers: {
         'Authorization': "Bearer " +   localStorage.getItem("user").replace('"','').replace('"','')
     }
   })
   }
   getDelFavoriteCases(id) {
    console.log(API_URL + 'delfavcases/'+id+'/');
    return axios
       .post(API_URL + 'delfavcases/'+id+'/', "", {
       headers: {
         'Authorization': "Bearer " +   localStorage.getItem("user").replace('"','').replace('"','')
     }
   })
   }
   
   getAddFavoriteCases(item) {
    return axios
       .post(API_URL + 'addfavcases', item, {
       headers: {
         'Authorization': "Bearer " +   localStorage.getItem("user").replace('"','').replace('"','')
     }
   })
   }
   getFavoriteCases() {
    return axios
       .post(API_URL + 'favcases', "", {
       headers: {
         'Authorization': "Bearer " +   localStorage.getItem("user").replace('"','').replace('"','')
     }
   })
   }
}

export default new UserService();
