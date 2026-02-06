import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-policy',
  imports: [FormsModule],
  templateUrl: './policy.html',
  styleUrl: './policy.css',
})
export class Policy {
  policy = {
    policyNo: '',
    issueDate: '',
    fromDate: '',
    toDate: '',
    assuredName: '',
    assuredMobile: '',
    currencyCode: '',
    grossFCPremium: 0,
    grossLCPremium: 0,
    vehicleMake: '',
    vehicleModel: '',
    chassisNumber: '',
    engineNumber: '',
    registrationNumber: '',
    vehicleValue: 0
  };
  savePolicy() {
    console.log(this.policy);
    alert("Policy saved (demo)");
  }
}
