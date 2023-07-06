'use strict';

$(function () {
  const select2 = $('.select2');

  

  // select2
  if (select2.length) {
    select2.each(function () {
      var $this = $(this);
      $this.wrap('<div class="position-relative"></div>');
      $this.select2({
      placeholder: 'يرجى الإختيار',
        dropdownParent: $this.parent()
      });
    });
  }
});
