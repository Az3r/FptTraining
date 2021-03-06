import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from './shared/services/auth.service';
import { IUser } from './shared/models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'ProductAngular';

  user?: IUser
  subscription?: Subscription;

  constructor(
    private authService: AuthService
  ) { }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe()
  }

  ngOnInit(): void {
    this.authService.user().then(user => this.user = user);
    this.subscription = this.authService.onChanged().subscribe(item => this.user = item);
  }

  logout() {
    this.authService.logout()
  }


}
