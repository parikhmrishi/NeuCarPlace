import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

const URL = environment.apiUrl;
@Injectable({
  providedIn: 'root'
})
export class CarsService {

  constructor( private http: HttpClient) { }

  getAllCars() {
    return this.http.get(URL+"cars")
  }

  getCar(id:number) {
    return this.http.get(URL+"cars/"+id)
  }
}
