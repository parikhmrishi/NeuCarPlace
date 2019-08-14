import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

const URL = environment.apiUrl;
@Injectable({
  providedIn: "root"
})
export class CarSpecificationService {
  constructor(private http: HttpClient) {}
  getSpecs() {
    return this.http.get(URL + "/carspecs");
  }
}
