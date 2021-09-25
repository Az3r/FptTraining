import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit {

  loginForm?: FormGroup
  submitting: boolean = false

  constructor(
    private snackbar: MatSnackBar,
    private router: Router,
    private fb: FormBuilder,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      name: ['', Validators.required],
      password: ['', Validators.required],
    })
  }

  get name() {
    return this.loginForm!.get('name') as FormControl
  }

  get password() {
    return this.loginForm!.get('password') as FormControl
  }

  getNameError() {
    if (this.name.hasError('required')) return 'this field is required'
    return ''
  }

  getPasswordError() {
    if (this.password.hasError('required')) return 'this field is required'
    return ''
  }

  async onSubmit() {
    this.submitting = true;
    const form = this.loginForm!.value;

    try {
      await this.authService.login(form.name, form.password);
      this.snackbar.open("Login successfully", undefined, {
        panelClass: ['snackbar-success'],
        horizontalPosition: "right"
      })
      this.router.navigate([''])
    } catch (error) {
      this.snackbar.open("Failed to login", undefined, {
        panelClass: ['snackbar-error'],
        horizontalPosition: "right"
      })
    } finally {
      this.submitting = false;
    }
  }
}
