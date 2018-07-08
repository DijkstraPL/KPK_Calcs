function checkIfAttitudeIsNeeded(selectedZone) {
    var elem = document.getElementById("attitiude");
    if (selectedZone === "2" || selectedZone === "8")
        elem.style.display = "none";
    else
        elem.style.display = "block";
}

function displayThermalCoefficient() {
    var thermalCoefficientFields = document.getElementById("thermalCoefficient");

    if (document.getElementById("calculate-thermal-coefficient").checked) {
        thermalCoefficientFields.style.display = "block";
    }
    else {
        thermalCoefficientFields.style.display = "none";
        document.getElementById("BuildingData_Building_InternalTemperature").value = "";
        document.getElementById("BuildingData_Building_OverallHeatTransferCoefficient").value = "";
    }
}

function checkIfExceptionalSituationIsPossible(selectedDesignSituation) {
    var elem = document.getElementById("exceptional-situation-block");
    var exceptional = document.getElementById("BuildingData_SnowLoad_ExcepctionalSituation");

    if (selectedDesignSituation === "0") {
        elem.style.display = "none";
        exceptional.check = false;
    }
    else
        elem.style.display = "block";
}

//$('input[name="BuildingData_SnowLoad_ExcepctionalSituation"][type="hidden"').remove();