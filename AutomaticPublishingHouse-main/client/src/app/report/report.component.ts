import {Component, OnInit} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss']
})
export class ReportComponent implements OnInit {
  report$: Observable<any[]>;

  constructor(private http: HttpClient) {
    this.report$ = http.get<any[]>(environment.apiUrl + '/Reports/printing-press');
  }

  ngOnInit(): void {
  }

  getContainersSumPrice(containers: any[]) {
    return containers?.map(x => x.count).reduce((a, b) => a + b, 0);
  }

  onDownloadPdf() {
    const data = document.getElementById ('report');
    html2canvas(data).then(canvas => {
      const fileWidth = 200;
      const fileHeight = canvas.height * fileWidth / canvas.width;

      const fileUrl = canvas.toDataURL('image/png');
      const pdf = new jsPDF('p', 'mm', 'a4');
      pdf.addImage(fileUrl, 'PNG', 0, 0, fileWidth, fileHeight);
      pdf.save('report.pdf');
    });
  }
}
