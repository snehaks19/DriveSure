import { Routes } from '@angular/router';
import { Login } from './login/login';
import { Dashboard } from './dashboard/dashboard';
import { Policy } from './policy/policy';
import { Claim } from './claim/claim';
import { Survey } from './survey/survey';
import { PolicyList } from './policy-list/policy-list';

export const routes: Routes = [
  { path: '', component: Login },
  { path: 'dashboard', component: Dashboard },
  { path: 'policy-list', component: PolicyList },
  { path: 'policy', component: Policy },
  { path: 'claim', component: Claim },
  { path: 'survey', component: Survey },
];
