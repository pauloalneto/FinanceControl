import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ActivationEnd, NavigationEnd, RouteConfigLoadEnd, RouteConfigLoadStart, Router, RouterEvent } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  menu: any = [];

  constructor(private activatedRoute: ActivatedRoute, private router: Router) {

    this.menu = [
      { icon: 'bi-bar-chart', route: '/dashboard', title: 'Dashboard' },
      {
        icon: 'bi-clipboard-data', route: '/', title: 'Reports', children:
          [
            { icon: '', route: '/', title: 'Invoice' }
          ]
      },
      { icon: 'bi-credit-card', route: '/', title: 'Cards' },
      { icon: 'bi-currency-dollar', route: '/', title: 'Invoices' },
      {
        icon: 'bi-gear', route: '/', title: 'Settings', children:
          [
            { icon: '', route: '/flag', title: 'Flags' },
            { icon: '', route: '/', title: 'Invoice Status' },
          ]
      },
    ]

  }

  ngOnInit(): void {

  }

  openSideNav(event: any) {
    console.log('testeclick ', event)
  }


}
