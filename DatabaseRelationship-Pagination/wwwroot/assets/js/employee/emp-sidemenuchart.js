(()=>{function e(e,o,r){return o in e?Object.defineProperty(e,o,{value:r,enumerable:!0,configurable:!0,writable:!0}):e[o]=r,e}$((function(o){var r,i=document.getElementById("sidemenuchart");new Chart(i,{type:"line",data:{labels:["Mon","Tues","Wed","Thurs","Fri","Sat","Sun"],type:"line",datasets:[{data:[15,18,15,19,22,19,20],label:"Desktops",backgroundColor:"rgba(71, 84, 242, 0.8)",borderColor:"#fff",borderWidth:"2",pointBackgroundColor:"rgba(71, 84, 242, 0.8)",pointBorderWidth:2,pointRadius:0,pointHoverRadius:4,pointHoverBackgroundColor:"#3366ff"}]},options:(r={responsive:!0,maintainAspectRatio:!1,legend:{display:!1}},e(r,"responsive",!0),e(r,"tooltips",{mode:"index",titleFontSize:12,titleFontColor:"#7886a0",bodyFontColor:"#7886a0",backgroundColor:"#fff",titleFontFamily:"Montserrat",bodyFontFamily:"Montserrat",cornerRadius:3,intersect:!1,enabled:!1}),e(r,"hover",{mode:"nearest",intersect:!0}),e(r,"scales",{xAxes:[{gridLines:{display:!1,color:"rgba(45, 53, 160, 0.3)",zeroLineColor:"rgba(45, 53, 160, 0.3)"},ticks:{display:!1}}],yAxes:[{gridLines:e({display:!1,color:"rgba(45, 53, 160, 0.3)",zeroLineColor:"rgba(45, 53, 160, 0.3)"},"display",!1),ticks:{display:!1,beginAtZero:!0,stepSize:10,max:30,min:0}}]}),e(r,"elements",{line:{borderWidth:1},point:{radius:4,hitRadius:10,hoverRadius:4}}),r)})}))})();