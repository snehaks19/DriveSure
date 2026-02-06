import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-dashboard',
  imports: [CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class Dashboard {
  constructor(private router: Router) { }

  userType: string = '';

  goToPolicy() {
    this.router.navigate(['/policy']);
  }

  goToClaim() {
    this.router.navigate(['/claim']);
  }

  goToSurvey() {
    this.router.navigate(['/survey']);
  }
  ngOnInit() {
    this.userType = localStorage.getItem('userType') || '';
  }
}
