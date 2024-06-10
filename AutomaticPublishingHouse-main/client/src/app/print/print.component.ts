import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";

@Component({
  selector: 'app-print',
  templateUrl: './print.component.html',
  styleUrls: ['./print.component.scss']
})
export class PrintComponent implements OnInit {
  prints$: Observable<any>;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.prints$ = this.http.get(`${environment.apiUrl}/PrintingPress`);
  }
}
