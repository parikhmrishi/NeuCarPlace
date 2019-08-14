import { Injectable } from "@angular/core";
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: "root"
})
export class AuthService implements CanActivate {
  constructor(private router: Router) {}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    try {
      if (localStorage.getItem('email') != null) {
        return true;
      } else {
        this.router.navigate(["login"]);
        localStorage.removeItem("email");
        return false;
      }
    } catch {
      this.router.navigate(["login"]);
      localStorage.removeItem("email");
    }
  }
}
