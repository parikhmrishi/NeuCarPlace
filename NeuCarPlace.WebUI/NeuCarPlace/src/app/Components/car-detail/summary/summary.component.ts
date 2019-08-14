import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { CarsService } from "src/app/Services/cars.service";
import { CarSpecificationService } from "src/app/Services/car-specification.service";
import { OrderService } from 'src/app/Services/order.service';

@Component({
  selector: "app-summary",
  templateUrl: "./summary.component.html",
  styleUrls: ["./summary.component.scss"]
})
export class SummaryComponent implements OnInit {
  carId: number;
  cars: any;
  show: boolean = false;
  constructor(
    private route: ActivatedRoute,
    private carspecificationService: CarSpecificationService,
    private orderService: OrderService,
    private router: Router
  ) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      console.log(params);
      this.carId = params["id"];
      this.carspecificationService.getSpecs().subscribe(data => {
        console.log(data);
        this.cars = data;
        this.show = true;
      });
    });
  }

  carBooking() {
    this.orderService
      .carBooking(localStorage.getItem("email"), this.carId)
      .subscribe(() => this.router.navigate(['home']));
  }

}
