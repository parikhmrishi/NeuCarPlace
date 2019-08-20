import { Component, OnInit } from "@angular/core";
//import { ICars } from "../../Interfaces/ICars";
import { CarsService } from "src/app/Services/cars.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"]
})
export class HomeComponent implements OnInit {
  show: boolean = false;
  cars: any;
  home: string = "";
  constructor(private carsService: CarsService, private router: Router) {}

  ngOnInit() {
    this.carsService.getAllCars().subscribe(
      cars => {
        this.cars = cars;
        if (this.cars.length !== 0) {
          this.show = true;
        }
        console.log(this.cars);
        this.home = this.router.url;
      },
      error => {
        this.show = false;
      }
    );
  }

  carDetails(car) {
    this.router.navigate(["cardetail/" + car.id]);
  }
}
