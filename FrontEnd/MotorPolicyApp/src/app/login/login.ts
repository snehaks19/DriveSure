import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Auth } from '../services/auth';
import { Route } from '../../../node_modules/@angular/router/types/_router_module-chunk';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import Swal from 'sweetalert2';



@Component({
  selector: 'app-login',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})

export class Login {
  loginForm!: any;
  submit = false;
  constructor(private auth: Auth, private router: Router, private fb: FormBuilder) {

    this.loginForm = this.fb.group({
      userId: ['', Validators.required],
      password: ['', Validators.required],
    }) }

  get f() {
    return this.loginForm.controls;
  }

  
  userId = '';
  password = '';

  login() {
    this.submit = true;
    const userId = this.loginForm.value.userId;
    const password = this.loginForm.value.password;
    this.auth.login(userId, password).subscribe({
      next: (res: any) => {
        localStorage.setItem('userType', res.userType)
        if (res.userType === "S") {
        //  alert("Surveyor Login Success");
        } else if (res.userType == "U") {
        //  alert("User Login Success");
        } else {
        //  alert("Login Success");
        }

        this.router.navigate(['/dashboard']);
      },
      error: (err: any) => {
        console.log(err);
        if (err.status === 401) {
          this.loginForm.reset();
          Swal.fire({
            icon: 'error',
            title: 'Invalid Credentials ❌',
            text: 'Username or password is incorrect',
            confirmButtonColor: '#d33'
          });

        } 
      }
    });

  }

  
}
    

