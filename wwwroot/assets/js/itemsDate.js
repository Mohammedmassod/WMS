
'use strict';

(function () {
  // Flat Picker
  // --------------------------------------------------------------------
  const flatpickrDisabledRange = document.querySelector('#flatpickr-disabled-range'),
        flatpickrDate = document.querySelector('#flatpickr-date');


  // Disabled Date Range
  if (flatpickrDisabledRange) {
    const fromDate = new Date(Date.now() - 3600 * 1000 * 48);
    const toDate = new Date(Date.now() + 3600 * 1000 * 48);

    flatpickrDisabledRange.flatpickr({
      dateFormat: 'Y-m-d',
      disable: [
        {
          from: fromDate.toISOString().split('T')[0],
          to: toDate.toISOString().split('T')[0]
        }
      ]
    });
  }
  // Date
  if (flatpickrDate) {
    flatpickrDate.flatpickr({
      monthSelectorType: 'static'
    });
  }
})();
