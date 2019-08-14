import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.scss"]
})
export class HeaderComponent implements OnInit {
  isLoggedIn: boolean = false;
  isHome: boolean = false;

  constructor(private router: Router) {}

  ngOnInit() {
    if (localStorage.getItem("email") != null) {
      this.isLoggedIn = true;
    }
    else {
      this.isLoggedIn = false;
    }
  }

  logOut() {
    localStorage.clear();
    this.isLoggedIn = false;
    this.router.navigate(["home"]);
  }
  login() {
    this.router.navigate(["login"]);
  }

  navigateHome() {
    this.router.navigate(["home"]);
  }
}
