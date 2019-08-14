import { Component, OnInit } from "@angular/core";
//import { ICars } from "../../Interfaces/ICars";
import { CarsService } from "src/app/Services/cars.service";
import { Router } from '@angular/router';

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"]
})
export class HomeComponent implements OnInit {
  // allcars: ICars[] = [];
  cars: any;
  home:string="";
  constructor(private carsService: CarsService, private router: Router) {}

  ngOnInit() {
    this.carsService.getAllCars().subscribe(cars => {
      this.cars = cars;
      console.log(cars);
      this.home = this.router.url;
      
    });
  }

  carDetails(car) {
    this.router.navigate(["cardetail/"+car.id])
  }
}
