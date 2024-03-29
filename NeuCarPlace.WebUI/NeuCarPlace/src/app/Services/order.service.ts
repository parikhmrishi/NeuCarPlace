import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { ICars } from '../Interfaces/ICars';
import { Observable } from 'rxjs';

const URL = environment.apiUrl;
@Injectable({
  providedIn: "root"
})
export class OrderService {
  constructor(private http: HttpClient) {}

  getOrders(email: string): Observable<ICars> {
    return this.http.get<ICars>(URL + "purchases/" + email);
  }

  checkBooking(email: string, carId: number) {
    return this.http.get(URL + "purchases/" + email + "/" + carId);
  }

  cancelBooking(email: string, carId: number) {
    return this.http.delete(URL + "purchases/" + email + "/" + carId);
  }

  carBooking(email: string, carId: number) {
    let body = {
      userId: email,
      carId: carId
    };
    return this.http.post(URL + "purchases/", body);
  }
}
