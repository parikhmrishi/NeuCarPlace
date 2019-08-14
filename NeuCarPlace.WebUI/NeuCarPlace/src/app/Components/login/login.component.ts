import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { UserService } from "src/app/Services/user.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"]
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  registerForm: FormGroup;
  login: Boolean = true;
  password: string;
  userData: object;
  constructor(
    private formBuilder: FormBuilder,
    private user: UserService,
    private router: Router
  ) {}

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      email: ["", Validators.required],
      password: ["", Validators.required]
    });

    this.registerForm = this.formBuilder.group({
      name: ["", Validators.required],
      email: ["", Validators.required],
      password: ["", Validators.required]
    });
   
  }

  submit() {
    this.password = this.loginForm.get("password").value;
debugger;
    this.user.getUserById(this.loginForm.get("email").value).subscribe(
      password => {
        this.checkPassword(password);
      },
      () => {
        alert("User cannot be found");
      }
    );

    console.log(this.loginForm.value);
  }

  register() {
    this.userData={
      name: this.registerForm.get('name').value,
      email: this.registerForm.get('email').value,
      password: this.registerForm.get('password').value
    }
    console.log(this.userData);
    this.user
      .postDetail(JSON.stringify(this.userData))
      .subscribe(response => this.router.navigate(['login']));
  }

  toggle() {
    this.login = !this.login;
  }

  checkPassword(password) {
    if (password == this.password) {
      localStorage.setItem("email", this.loginForm.get('email').value)
      this.navigateHome();
    } else {
      alert("Incorrect Password");
    }
  }

  navigateHome() {
    this.router.navigate(["home"]);
  }
}
