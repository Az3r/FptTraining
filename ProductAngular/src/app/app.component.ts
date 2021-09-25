import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from './auth/auth.service';
import { IAuthToken } from './shared/auth';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'ProductAngular';

  user?: IAuthToken
  subscription: Subscription;

  constructor(
    private authService: AuthService
  ) { }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe()
  }

  ngOnInit(): void {
    this.user = this.authService.user()
    this.subscription = this.authService.onChanged().subscribe(item => {
      console.log("auth changed", item)
      return this.user = item;
    });
  }

  logout() {
    this.authService.logout()
  }


}
