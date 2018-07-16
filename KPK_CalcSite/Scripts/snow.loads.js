window.addEventListener("load", displayThermalCoefficient())
window.addEventListener("load",
    checkIfAttitudeIsNeeded(document.getElementById("BuildingData_BuildingSite_CurrentZone").value))
window.addEventListener("load",
    checkIfExceptionalSituationIsPossible(document.getElementById("BuildingData_SnowLoad_CurrentDesignSituation").value))
window.addEventListener("load",
    checkSnowType(document.getElementById("snowType").value))
window.addEventListener("load",
    checkIfExceptional(document.getElementById("exceptional").value))

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
    var isExceptional = document.getElementById("exceptional");
    var currentDesignSituation = document.getElementById("BuildingData_SnowLoad_CurrentDesignSituation");
    
    if (isExceptional.textContent == "True") {
        exceptional.checked = true;
        exceptional.hidden = true;
        elem.style.display = "none";

        if (currentDesignSituation.childElementCount === 4) {
            currentDesignSituation.remove("0");
            currentDesignSituation.remove("0");
        }
    }
    else {
        if (selectedDesignSituation === "0") {
            elem.style.display = "none";
            exceptional.checked = false;
        }
        else if (selectedDesignSituation === "2") {
            exceptional.checked = false;
            elem.style.display = "block";
            exceptional.disabled = true;
        }
        else {
            exceptional.disabled = false;
            elem.style.display = "block";
        }
    }
}

function checkSnowType(snowType) {
    //var snowType = document.getElementById("snowType");
    var snowDensity = document.getElementById("snowDensity");
    var snowDensitySetter = document.getElementById("SnowLoadRoofAbuttingToTallerConstruction_BuildingData_SnowLoad_SnowDensity");
    if (snowDensitySetter == null)
        snowDensitySetter = document.getElementById("SnowLoadDriftingAtProjectionsObstructions_BuildingData_SnowLoad_SnowDensity");
    if (snowDensitySetter == null)
        snowDensitySetter = document.getElementById("SnowOverhanging_BuildingData_SnowLoad_SnowDensity");
        
    if (snowType === "old") {
        snowDensity.style.display = "block";
    }
    else {
        snowDensity.style.display = "none";
    }

    if (snowType === "fresh")
        snowDensitySetter.value = "1";
    else if (snowType === "settled")
        snowDensitySetter.value = "2";
    else if (snowType === "old")
        snowDensitySetter.value = snowDensity.value;
    else if (snowType === "wet")
        snowDensitySetter.value = "4";
}

