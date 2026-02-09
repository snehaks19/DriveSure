import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-policy-list',
  imports: [],
  templateUrl: './policy-list.html',
  styleUrl: './policy-list.css',
})
export class PolicyList {
  constructor(private router: Router) { }

  editPolicy(id: number) {
    this.router.navigate(['/policy', id]);
  }

  addPolicy() {
    this.router.navigate(['/policy']);
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
