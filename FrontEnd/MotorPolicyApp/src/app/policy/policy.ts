import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { OnInit } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { Codes } from '../services/codes';
import { CommonModule } from '@angular/common';
import { PolicyService } from '../services/policy-service';


@Component({
  selector: 'app-policy',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './policy.html',
  styleUrl: './policy.css',
})
export class Policy implements OnInit {

  policyForm!: any;
  ListCurrency: any[] = [];
  ListVehicleMake: any[] = [];
  ListVehicleModel: any[] = [];
  constructor(private fb: FormBuilder, private codesService: Codes, private policyService: PolicyService) { }



  ngOnInit() {

    this.setUpDates();
    this.loadDropdowns();
    this.loadGrid();
  }

  loadGrid() {
    this.policyService.getPolicies().subscribe({res=})
  }

  onSubmit() {

    const formData = this.policyForm.value;

    console.log(formData);

    this.policyService.submitPolicy(formData).subscribe({
      next: (res: any) => console.log('Success:', res),
      error: (err: any) => console.log("FULL ERROR:", err.error)
    });
  }



  loadDropdowns() {

    this.codesService.getddl("CURRENCY").subscribe((res: any[]) => {
      this.ListCurrency = res;
      console.log(this.ListCurrency)
    });
    this.codesService.getddl("VEH_MAKE").subscribe((res: any[]) => {
      console.log(res)  
      this.ListVehicleMake = res;
    });

  }

  onMakeChange(event: Event) {
    const vehMakeCode = (event.target as HTMLInputElement).value;

    console.log("make code:",vehMakeCode);
    this.codesService.getddl("VEH_MODEL", vehMakeCode).subscribe((res: any[]) => {
      console.log(res)
      this.ListVehicleModel = res;
    })
  }

  setUpDates() {
    const today = new Date().toISOString().split('T')[0];

    this.policyForm = this.fb.group({
      issueDate: [today],
      fromDate: [today],
      toDate: [''],
      currency: [''],
      vehMake: [''],
      vehModel: [''],
      name: [''],
      mobile: [''],
      fcPremium: [0],
      lcPremium: [0],
      chassisNo: [''],
      engineNo: [''],
      regNo: [''],
      vehValue: [0],
      polNo: ['']

    });

    this.policyForm.get('fromDate')?.valueChanges.subscribe((date: any) => {
      this.calculateToDate(date);
    });

    // ✅ trigger once on page load
    this.calculateToDate(this.policyForm.get('fromDate')?.value);


  }

  calculateToDate(date: string) {

    if (!date) return;

    const from = new Date(date);
    from.setDate(from.getDate() + 364);

    this.policyForm.patchValue({
      toDate: this.formatDate(from)
    }, { emitEvent: false });

  }
  formatDate(date: Date): string {
    return date.toISOString().split('T')[0];
  }

 
}
