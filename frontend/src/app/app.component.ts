import { Component, OnInit } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  relatorio:any;
  title = 'app';

  constructor(private _http: Http) {
  }

  ngOnInit(): void {
    this._http.get("http://localhost:60499/api/data")
      .subscribe(data=>{
        var html: any = data;
        // console.log(html._body);
        this.relatorio = html._body;
       
      });
  }

  render(){
    var _div: any = document.getElementById("output");
    _div.innerHTML = this.relatorio;
  }

}