
window.addEventListener("load", displayCoefficients())
var windowStarted = false;
var showResults = false;

function displayCoefficients() {
	windowStarted = true;

	barFormCoverChanged();
	transverseReinforcementChanged();
	transversePressureChanged();

	windowStarted = false;

}

function dataChanged() {
	var results = document.getElementById("results");
    if (showResults && results != null)
		results.style.display = "block";
    else if (results != null)
		results.style.display = "none";
}

function showResults() {
	showResults = true;
	dataChanged();
}

function barFormCoverChanged() {
	//if (windowStarted)
		dataChanged();

	var barFormChecked = document.getElementById("CalculateBarFormCoefficient").checked;
	var coverChecked = document.getElementById("CalculateCoverCoefficient").checked;

	var barFormCoverForm = document.getElementById("barForm-cover-Form");

	if (barFormChecked || coverChecked)
		barFormCoverForm.style.display = "block";
	else
		barFormCoverForm.style.display = "none";
}

function transverseReinforcementChanged() {
	//if (windowStarted)
		dataChanged();

	var transverseReinforcement = document.getElementById("CalculateTransverseReinforcementCoefficient").checked;

	var transverseReinforcementForm = document.getElementById("transverseReinforcement-Form");

	if (transverseReinforcement)
		transverseReinforcementForm.style.display = "block";
	else
		transverseReinforcementForm.style.display = "none";
}

function transversePressureChanged() {
	//if (windowStarted)
		dataChanged();

	var transversePressure = document.getElementById("CalculateTransversePressureCoefficient").checked;

	var transversePressureForm = document.getElementById("transversePressure-Form");

	if (transversePressure)
		transversePressureForm.style.display = "block";
	else
		transversePressureForm.style.display = "none";
}