import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";

@Component({
  selector: 'app-material',
  templateUrl: './material.component.html',
  styleUrls: ['./material.component.scss']
})
export class MaterialComponent implements OnInit {
  materials$: Observable<any>;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.materials$ = this.http.get(`${environment.apiUrl}/Material`);
  }
}
