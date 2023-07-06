
(function () {
  
    const selectAll = document.querySelector('#selectAll'),
    checkboxList = document.querySelectorAll('[type="checkbox"]'),
    filterInput = [].slice.call(document.querySelectorAll('.input-filter'));
  selectAll.addEventListener('change', t => {
    checkboxList.forEach(e => {
      e.checked = t.target.checked;
    });
  });
    filterInput.forEach(item => {
      item.addEventListener('click', () => {
        document.querySelectorAll('.input-filter:checked').length < document.querySelectorAll('.input-filter').length
          ? (selectAll.checked = false)
          : (selectAll.checked = true);
        calendar.refetchEvents();
      });
    });
  
  ////----radio button-----
  const checkbox1 =document.getElementById("check1");
  const checkbox2 =document.getElementById("check2");
  const checkbox3 =document.getElementById("check3");
  
  ///----in the start--
  checkbox1.checked=false;
  checkbox2.checked=false;
  checkbox3.checked=false;
  
  
  
  document.getElementById("fromTemperature").disabled = true; 
  document.getElementById("toTemperature").disabled = true;
  document.getElementById("fromHumidity").disabled = true;
  document.getElementById("toHumidity").disabled = true;
  document.getElementById("fromLighting").disabled = true;
  document.getElementById("toLighting").disabled = true;
  
  //----- when click on buttons ---
  checkbox1.onclick = function () {  if(checkbox1.checked=true){
    document.getElementById("fromTemperature").disabled = false; 
    document.getElementById("toTemperature").disabled = false;
    // document.getElementById("fromHumidity").disabled = true;
    // document.getElementById("toHumidity").disabled = true;
    // document.getElementById("fromLighting").disabled = true;
    // document.getElementById("toLighting").disabled = true;
  }
  else{
    document.getElementById("fromTemperature").disabled = true; 
    document.getElementById("toTemperature").disabled = true;
  };
  
  
  };
  checkbox2.onclick = function () {  if(checkbox2.checked=true){
    // document.getElementById("fromTemperature").disabled = true; 
    // document.getElementById("toTemperature").disabled = true;
    document.getElementById("fromHumidity").disabled = false;
    document.getElementById("toHumidity").disabled = false;
    // document.getElementById("fromLighting").disabled = true;
    // document.getElementById("toLighting").disabled = true;
  };
  }
  checkbox3.onclick = function () {  if(checkbox3.checked=true){
    // document.getElementById("fromTemperature").disabled = true; 
    // document.getElementById("toTemperature").disabled = true;
    // document.getElementById("fromHumidity").disabled = true;
    // document.getElementById("toHumidity").disabled = true;
    document.getElementById("fromLighting").disabled = false;
    document.getElementById("toLighting").disabled = false;
   };
   }
  }
   
   )();
   
  
  