/**
 * Sweet Alerts
 */

'use strict';

(function () {
  const iconedit = document.querySelector('#type-edit'),
        confirmText = document.querySelector('#confirm-text'),
        iconSuccess = document.querySelector('#type-success'),
        iconSuccess2 = document.querySelector('#type-success-transport'),
        iconSuccess3 = document.querySelector('#type-success-movement'),
        iconSuccess4 = document.querySelector('#type-success-send'),
        iconSuccess5 = document.querySelector('#type-success-add');
  
  
  // Alert Types
  // --------------------------------------------------------------------

  // Success Alert
  if (iconSuccess) {
     /* if(){
          Swal.fire({
            text: 'لقد قمت بإدخال بيانات صف تم إدخاله مسبقاً سيتم تكرار البيانات ',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'موافق',
            cancelButtonText: 'إلغاء',
            customClass: {
              confirmButton: 'btn btn-primary me-2',
              cancelButton: 'btn btn-label-secondary'
            },
            buttonsStyling: false
          }).then(function (result) {
            if (result.value) {
              Swal.fire({
                icon: 'success',
                confirmButtonText: 'موافق',
                title: ' تم الحفظ بنجاح',
                customClass: {
                  confirmButton: 'btn btn-success'
                }
              });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
              Swal.fire({
                title: 'إلغاء',
                text: 'تم إلغاء عملية الحفظ',
                icon: 'error',
                confirmButtonText: 'موافق',
                customClass: {
                  confirmButton: 'btn btn-success'
                }
              });
            }
          });
        }
        else{ */
    iconSuccess.onclick = function () {
      Swal.fire({
        title: 'تم الحفظ بنجاح',
        confirmButtonText: 'موافق',
        icon: 'success',
        customClass: {
          confirmButton: 'btn btn-success',
          
        },
        buttonsStyling: false
      });
    };
     //}
  }
  
  // Success Alert
  if (iconSuccess2) {
    iconSuccess2.onclick = function () {
      Swal.fire({
        title: 'تم النقل بنجاح',
        confirmButtonText: 'موافق',
        icon: 'success',
        customClass: {
          confirmButton: 'btn btn-success',
          
        },
        buttonsStyling: false
      });
    };
  }

    // Success Alert
    if (iconSuccess3) {
      iconSuccess3.onclick = function () {
        Swal.fire({
          title: 'تم التحريك بنجاح',
          confirmButtonText: 'موافق',
          icon: 'success',
          customClass: {
            confirmButton: 'btn btn-success',
            
          },
          buttonsStyling: false
        });
      };
    }

    // Success Alert
  if (iconSuccess4) {
    iconSuccess4.onclick = function () {
      Swal.fire({
        title: 'تم بنجاح',
        confirmButtonText: 'موافق',
        icon: 'success',
        customClass: {
          confirmButton: 'btn btn-success',
          
        },
        buttonsStyling: false
      });
    };
  }
  
    // Success Alert
    if (iconSuccess5) {
      iconSuccess5.onclick = function () {
        Swal.fire({
          title: 'تم بنجاح',
          confirmButtonText: 'موافق',
          icon: 'success',
          customClass: {
            confirmButton: 'btn btn-success',
            
          },
          buttonsStyling: false
        });
      };
    }
 // Info Alert
 if (iconedit) {
  iconedit.onclick = function () {
    Swal.fire({
      title: 'تعديل!',
      text: '',
      icon: 'info',
      confirmButtonText: 'نعم',
      customClass: {
        confirmButton: 'btn btn-info'
      },
      buttonsStyling: false
    });
  };
}
 
// Alert With Functional Confirm Button
if (confirmText) {
  confirmText.onclick = function () {
    Swal.fire({
      title: 'هل أنت متأكد من أنك تريد الحذف ؟',
      text:"",
      icon: 'error',
      showCancelButton: true,
      confirmButtonText: 'نعم',
      cancelButtonText: 'إلغاء',
      customClass: {
        confirmButton: 'btn btn-primary me-3',
        cancelButton: 'btn btn-label-secondary',
        
      },
      buttonsStyling: false
    }).then(function (result) {
      if (result.value) {
        Swal.fire({
          icon: 'success',
          title: 'تم الحذف',
          text: '',
          confirmButtonText: 'موافق',
          customClass: {
            confirmButton: 'btn btn-success'
          }
        });
      }
    });
  };
}
 
})();
