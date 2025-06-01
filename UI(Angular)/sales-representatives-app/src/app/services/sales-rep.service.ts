import { inject, Injectable } from '@angular/core';
import { SalesRep } from '../models/sales-rep.model';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class SalesRepService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7260/api/SalesRep/get'; // 🔁 Replace with your real URL


  getSalesReps(): Observable<SalesRep[]> {
  return this.http.get<SalesRep[]>(this.apiUrl);
  }

  // getSalesReps(): Observable<SalesRep[]> {
  //   return this.salesRepsSubject.asObservable();
  // }

  updateSalesRep(updated: SalesRep): void {
    // const index = this.salesReps.findIndex(r => r.id === updated.id);
    // if (index !== -1) {
    //   this.salesReps[index] = updated;
    //   this.salesRepsSubject.next([...this.salesReps]);
    // }
  }
}