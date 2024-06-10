import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {environment} from "../../../environments/environment";

@Component({
  selector: 'app-add-print',
  templateUrl: './add-print.component.html',
  styleUrls: ['./add-print.component.scss']
})
export class AddPrintComponent implements OnInit {
  form: FormGroup;

  constructor(private http: HttpClient,
              private router: Router) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(),
    });
  }

  onAddEdition() {
    this.http.post(`${environment.apiUrl}/PrintingPress`, this.form.value)
      .subscribe(() => this.router.navigateByUrl('/print'));
  }
}
