import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";

@Component({
  selector: 'app-dye',
  templateUrl: './dye.component.html',
  styleUrls: ['./dye.component.scss']
})
export class DyeComponent implements OnInit {

  dyes$: Observable<any>;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.dyes$ = this.http.get(`${environment.apiUrl}/Dyes`);
  }

}
