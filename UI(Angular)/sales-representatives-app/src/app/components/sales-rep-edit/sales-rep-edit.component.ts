import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { SalesRepService } from '../../services/sales-rep.service';
import { SalesRep } from '../../models/sales-rep.model';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-sales-rep-edit',
  standalone: true,
  imports: [NgIf, FormsModule, RouterLink],
  templateUrl: './sales-rep-edit.component.html'
})
export class SalesRepEditComponent implements OnInit {
  salesRep: SalesRep | undefined;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private salesRepService: SalesRepService
  ) {}

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.salesRepService.getSalesReps().subscribe(reps => {
      this.salesRep = reps.find(r => r.id === id);
    });
  }

  save(): void {
    if (this.salesRep) {
      this.salesRepService.updateSalesRep(this.salesRep);
      this.router.navigate(['/']);
    }
  }
}
