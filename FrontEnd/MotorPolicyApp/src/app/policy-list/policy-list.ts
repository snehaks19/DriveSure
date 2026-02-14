import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PolicyService } from '../services/policy-service';
import { CommonModule } from '@angular/common';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@Component({
  selector: 'app-policy-list',  
  imports: [CommonModule, NgxDatatableModule],
  templateUrl: './policy-list.html',
  styleUrl: './policy-list.css',
})
export class PolicyList {

  PolicyList: any[] = [];

  constructor(private router: Router, private policyService: PolicyService) { }

  ngOnInit() {

    this.loadGrid();
  }

  loadGrid() {
    this.policyService.getPolicies()
      .subscribe((res: any[]) => {
        console.log("API DATA:", res);
        this.PolicyList = res;
      });
  }

  editPolicy(id: number) {
    this.router.navigate(['/policy', id]);
  }

  addPolicy() {
    this.router.navigate(['/policy']);
  }

  goDashboard() {
    this.router.navigate(['/dashboard']);
  }

  //deletePolicy(id: number) {

  //  if (!confirm("Delete this policy?")) return;

  //  this.policyService.deletePolicy(id)
  //    .subscribe(() => {
  //      alert("Deleted successfully");
  //      this.loadPolicies();
  //    });
  //}

}
