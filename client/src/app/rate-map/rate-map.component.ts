import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';

@Component({
  selector: 'app-rate-map',
  templateUrl: './rate-map.component.html',
  styleUrls: ['./rate-map.component.scss']
})
export class RateMapComponent implements OnInit {
  dyes$: Observable<any>;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.dyes$ = this.http.get(`${environment.apiUrl}/Statistics/dye`);
  }
}
