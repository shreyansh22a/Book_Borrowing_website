import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-animated-alert',
  templateUrl: './animated-alert.component.html',
  styleUrls: ['./animated-alert.component.css']
})
export class AnimatedAlertComponent {
  @Input() type: 'success' | 'failure' = 'success';
  @Input() message: string | undefined;

  constructor() {}
}
