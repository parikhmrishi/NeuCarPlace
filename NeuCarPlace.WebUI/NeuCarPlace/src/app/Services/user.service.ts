import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

const URL = environment.apiUrl

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private http: HttpClient) { }

  getUserById(username: string) {
    return this.http.get(URL+"users/"+username);
  }

  postDetail(userInformation) {
    console.log(JSON.parse(userInformation));
    
    return this.http.post(URL+"users/", JSON.parse(userInformation) )
  }
  
}
