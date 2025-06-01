import { Routes } from '@angular/router';
import { SalesRepListComponent } from './components/sales-rep-list/sales-rep-list.component';
import { SalesRepEditComponent } from './components/sales-rep-edit/sales-rep-edit.component';

export const routes: Routes = [
  { path: '', component: SalesRepListComponent },
  { path: 'edit/:id', component: SalesRepEditComponent }
];
