import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";

@Component({
  selector: 'app-edition',
  templateUrl: './edition.component.html',
  styleUrls: ['./edition.component.scss']
})
export class EditionComponent implements OnInit {
  editions$: Observable<any>;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.editions$ = this.http.get(`${environment.apiUrl}/Editions`);
  }
}
