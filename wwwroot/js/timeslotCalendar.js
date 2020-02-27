var oldList;
$(document).ready(getCalendar);
function getCalendar(){
  var theBody = {
    'PractitionerId': $('#practSelector').val(),
    'ServiceId': $('#servSelector').val(),
    'CustomerId': $('#custSelector').val(),
  }
  var theBodyString = JSON.stringify(theBody);
  $.ajax({
    method: "POST",
    url: "/calendarFilterJson",
    data: {'': theBodyString}
    }).done(function(res){
      oldList = JSON.parse(res);
      makeCalendar(oldList);
    })
}
function makeCalendar(myEventList){
  if (document.getElementById("calendar").innerHTML != "") {
    document.getElementById("calendar").innerHTML = "";
  }
  /* initialize the calendar
  -----------------------------------------------------------------*/


  var Calendar = FullCalendar.Calendar;

  var calendarEl = document.getElementById('calendar');

  var calendar = new Calendar(calendarEl, {
    timeZone: 'UTC',
    plugins: [ 'bootstrap', 'interaction', 'dayGrid', 'timeGrid' ],
    header    : {
      left  : 'prev,next today',
      center: 'title',
      right : 'dayGridMonth,timeGridWeek,timeGridDay'
    },
    //Random default events
    events    : myEventList.result,
    eventClick: function(info){
      let oldtsid = $('#tsid').val();
      if (oldtsid != "0"){
        // need to somehow change hte old events bg color back to black
      }
        $('#tsid').val(info.event.id);
        info.event.borderColor = "red";
    },
    editable  : false,
    droppable : false, // this allows things to be dropped onto the calendar !!!
  });

  calendar.render();
}
$('#custSelector').change(getCalendar);
$('#practSelector').change(getCalendar);
$('#servSelector').change(getCalendar);