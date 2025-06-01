import { Component, inject, OnInit } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { SalesRepService } from '../../services/sales-rep.service';
import { SalesRep } from '../../models/sales-rep.model';

@Component({
  selector: 'app-sales-rep-list',
  standalone: true,
  imports: [NgFor, NgIf, FormsModule, RouterLink],
  templateUrl: './sales-rep-list.component.html'
})
export class SalesRepListComponent implements OnInit {
  salesRepService = inject(SalesRepService);
  salesReps: SalesRep[] = [];
  filteredReps: SalesRep[] = [];
  filters = { product: '', region: '' , salesPerformance:'', salesRep: ''};
  searchText:string ='';

  constructor() {}

  ngOnInit(): void {
    this.salesRepService.getSalesReps().subscribe(data => {
      this.salesReps = data;
      this.applyFilters();
    });
  }

  applyFilters(): void {
    this.filteredReps = this.salesReps.filter(rep => {
      return (
        (rep.name.toLowerCase().includes(this.searchText.toLowerCase()) 
        || !this.searchText) &&
        (!this.filters.product || rep.product === this.filters.product) &&
        (!this.filters.region || rep.region === this.filters.region) &&
        (!this.filters.salesPerformance || rep.salesPerformance === this.filters.salesPerformance)
      );
    });
  }
}
