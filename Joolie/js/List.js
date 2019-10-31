$().ready(function () {
    // CLear the input of the left side bar
   
    $("#clear").click(function () {
        $(this).closest('form').find("input[type=text], Textbox").val("");
        console.log("fffffffffffffffffffffffff");
    });
    // toggle icon for Product Type header

    $(document).on('click', '.anchorCollapse', function () {
        
        $('i',this).toggleClass('fa-caret-down fa-caret-up');
    });
    //  Model Year Slider code #######################
    var fanproperties_MinModelYear = $("#fanproperties_MinModelYear");

    var fanproperties_MinModelYear = $("#fanproperties_MaxModelYear");


    // end of  Modelyear widget code #######################  

    //  AirFlow Slider code #######################
    var MinAirFLow = $("#fanproperties_MinAirFlow");
   
    var MaxAirFLow = $("#fanproperties_MaxAirFlow");
     
    var Min = MinAirFLow.val();
    var Max = MaxAirFLow.val();
    var AirFlowSlider = $("#AirFlowSlider");
    AirFlowSlider.slider({
        range: true,
        min: parseInt(Min),
        max: parseInt(Max),
        values: [parseInt(Min), parseInt(Max)],
        slide: function (even, ui) {
         
            $(document).find("input[id=fanproperties_MinAirFlow], Textbox").val(ui.values[0]);
            $(document).find("input[id=fanproperties_MaxAirFlow], Textbox").val(ui.values[1]);
            
        }
       
      
    });
  
    
 

    // end of  AirFlow widget code #######################    
    //  Max Power Slider code #######################
    var MinMaxPower = $("#fanproperties_MinMaxPower");
    var MaxMaxPower = $("#fanproperties_MaxMaxPower");
    var MaxPowerSlider = $("#MaxPowerSlider");
    MaxPowerSlider.slider({
        range: true,
        min: parseInt(MinMaxPower.val()),
        max: parseInt(MaxMaxPower.val()),
        values: [parseInt(MinMaxPower.val()), parseInt(MaxMaxPower.val())],
        slide: function (even, ui) {
         
            $(document).find("input[id=fanproperties_MinMaxPower], Textbox").val(ui.values[0]);
            $(document).find("input[id=fanproperties_MaxMaxPower], Textbox").val(ui.values[1]);
        }


    });
    $(document).on('click', '.btnAirflowUP', function () {
       // MinAirFLow.val(MinAirFLow.val() + 20);
    });

    // end of  Max power  code #######################    
    //  Fan Sweep dimater  Slider code #######################
    var MinFanSweepdiameter = $("#fanproperties_MinFanSpeedDimater");
   
    var MaxFanSweepdiameter = $("#fanproperties_MaxFanSpeedDimater");

    $("#FanSweepdiameterSlider").slider({
        range: true,
        min: parseInt(MinFanSweepdiameter.val()),
        max: parseInt(MaxFanSweepdiameter.val()),
        values: [parseInt(MinFanSweepdiameter.val()), parseInt(MaxFanSweepdiameter.val())],
        slide: function (even, ui) {
            $(document).find("input[id=fanproperties_MinFanSpeedDimater], Textbox").val(ui.values[0]);
            $(document).find("input[id=fanproperties_MaxFanSpeedDimater], Textbox").val(ui.values[1]);
        }


    });
    $(document).on('click', '.btnAirflowUP', function () {
        // MinAirFLow.val(MinAirFLow.val() + 20);
    });

    // end of  Fan Sweep diameter  code #######################   

    //  Height  Slider code #######################
    var MinHeight = $("#fanproperties_MinHeight");
   // MinHeight.val(10);
    var MaxHeight = $("#fanproperties_MaxHeight");
   // MaxHeight.val(100);
    $("#HeightSlider").slider({
        range: true,
        min: parseInt(MinHeight.val()),
        max: parseInt(MaxHeight.val()),
        values: [parseInt(MinHeight.val()), parseInt(MaxHeight.val())],
        slide: function (even, ui) {
            $(document).find("input[id=fanproperties_MinHeight], Textbox").val(ui.values[0]);
            $(document).find("input[id=fanproperties_MaxHeight], Textbox").val(ui.values[1]);
        }


    });
    $(document).on('click', '.btnAirflowUP', function () {
        // MinAirFLow.val(MinAirFLow.val() + 20);
    });

    // end of  Height (in) code #######################   
    //  Firm  Slider code #######################
    var MinFirm = $("#fanproperties_MinFirm");
   // MinFirm.val(10);
    var MaxFirm = $("#fanproperties_MaxFirm");
  //  MaxFirm.val(100);
    $("#FirmSlider").slider({
        range: true,
        min: parseInt(MinFirm.val()),
        max: parseInt(MaxFirm.val()),
        values: [parseInt(MinFirm.val()), parseInt(MaxFirm.val())],
        slide: function (even, ui) {
            $(document).find("input[id=fanproperties_MinFirm], Textbox").val(ui.values[0]);
            $(document).find("input[id=fanproperties_MaxFirm], Textbox").val(ui.values[1]);
        }


    });
    $(document).on('click', '.btnAirflowUP', function () {
        // MinAirFLow.val(MinAirFLow.val() + 20);
    });

    // end of  Firm slider (in) code #######################   

    //  Global  Slider code #######################
    var MinGlobal = $("#fanproperties_MinGlobal");
  //  MinGlobal.val(10);
    var MaxGlobal = $("#fanproperties_MaxGlobal");
   // MaxGlobal.val(100);
    $("#GlobalSlider").slider({
        range: true,
        min: parseInt(MinGlobal.val()),
        max: parseInt(MaxGlobal.val()),
        values: [parseInt(MinGlobal.val()), parseInt(MaxGlobal.val())],
        slide: function (even, ui) {
            $(document).find("input[id=fanproperties_MinGlobal], Textbox").val(ui.values[0]);
            $(document).find("input[id=fanproperties_MaxGlobal], Textbox").val(ui.values[1]);
        }


    });
    $(document).on('click', '.btnAirflowUP', function () {
        // MinAirFLow.val(MinAirFLow.val() + 20);
    });

    // end of  Global slider (in) code #######################   
});// end of ready function