import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  template: `<h2  style="background-color: grey; color: white; text-align: center; padding: 10px;">
  Sales Representative Management System</h2>
  <router-outlet></router-outlet>`
})
export class AppComponent {}