import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Visit } from 'src/app/shared/models/Visit';
import { SelectItem } from 'primeng/primeng';
import { VisitStatus } from 'src/app/shared/enums/VisitStatus';
import { Opinion } from '../../models/Opinion';
@Component({
  selector: 'app-view-visits-list',
  templateUrl: './view-visits-list.component.html',
  styleUrls: ['./view-visits-list.component.css']
})
export class ViewVisitsListComponent implements OnInit {

  @Input() visits: Visit[] = [];
  @Input() isClient = true;
  @Output() addedOpinion = new EventEmitter<Opinion>();
  displayingVisits: Visit[] = [];

  sortOptions: SelectItem[] = [
    {label: 'Status info', value: 'status'},
    {label: 'Status warn', value: '!status'},
    {label: 'Incoming', value: 'term'},
    {label: 'Far in time', value: '!term'}
  ];

  filterOptions: SelectItem[] = [
    {label: 'Accepted', icon: 'pi pi-check-circle', value: VisitStatus.Accepted,
     styleClass: 'my-accepted-button'},
    {label: 'CL requested', icon: 'pi pi-question-circle', value: VisitStatus.ClientChangeRequested,
     styleClass: 'my-client-change-button'},
    {label: 'HD requested', icon: 'pi pi-exclamation-circle', value: VisitStatus.WorkerChangeRequested,
     styleClass: 'my-worker-change-button'},
    {label: 'Pending', icon: 'pi pi-clock', value: VisitStatus.Pending,
     styleClass: 'my-pending-button'},
    {label: 'Rejected', icon: 'pi pi-times-circle', value: VisitStatus.Rejected,
     styleClass: 'my-rejected-button'}
  ];
  selectedFilters: VisitStatus[] = [VisitStatus.Accepted, VisitStatus.ClientChangeRequested,
     VisitStatus.WorkerChangeRequested, VisitStatus.Pending, VisitStatus.Rejected];
  showHistoryFlag = false;

  sortKey: string;
  sortField: string;
  sortOrder: number;

  constructor() { }

  ngOnInit() {
    this.sortKey = this.sortOptions[2].value;
    this.refreshFilters(this.selectedFilters, this.showHistoryFlag);
  }

  onSortChange(event) {
    this.sortDisplayingVisits(event);
  }

  private sortDisplayingVisits(sortOption: string) {
    let descendig = false;
    let value = sortOption;
    if (value.indexOf('!') === 0) {
        descendig = true;
        value = value.slice(1, value.length);
    }
    if (value === 'status') {
      this.displayingVisits.sort((v1, v2) => {
        if (v1.status > v2.status) {
          if (descendig) { return -1; } else { return 1; }
        }
        if (v1.status < v2.status) {
          if (descendig) { return 1; } else { return -1; }
        }
        return 0;
      });
    }
    if (value === 'term') {
      this.displayingVisits.sort((v1, v2) => {
        if (v1.term > v2.term) {
          if (descendig) { return -1; } else { return 1; }
        }
        if (v1.term < v2.term) {
          if (descendig) { return 1; } else { return -1; }
        }
        return 0;
      });
    }
  }

  filterVisits(filters: VisitStatus[]) {
    this.displayingVisits = this.visits.filter(v => filters.includes(v.status));
  }

  showHistory(show: boolean) {
    const now = new Date();
    if (!show) {
      this.displayingVisits = this.displayingVisits.filter(v => new Date(v.term) > now);
      this.sortOptions[2].label = 'Incoming';
      this.sortOptions[3].label = 'Far in time';
    } else {
      this.displayingVisits = this.displayingVisits.filter(v => new Date(v.term) <= now);
      this.sortOptions[2].label = 'Oldest';
      this.sortOptions[3].label = 'Latest';
    }
  }

  refreshFilters(filters: VisitStatus[], showHistory: boolean) {
    this.filterVisits(filters);
    this.showHistory(showHistory);
    this.sortDisplayingVisits(this.sortKey);
  }

  onAddedOpinion(opinion: Opinion) {
    this.addedOpinion.emit(opinion);
  }


}
