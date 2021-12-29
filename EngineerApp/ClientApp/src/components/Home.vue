<template>
    <div class="container">
        <div class="large-12 medium-12 small-12 cell">
            <div class="row">
                <div class="col-md">
                    <div class="row">
                        <div class="col-md">
                            Stop:
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md">
                            <select v-model="selectedPerson" style="width: 203px; height: 48px">
                                <option v-for="person in people" :key="person.key">{{person.name}}</option>
                            </select>
                        </div>
                    </div>
                </div>

                <div class="col-md">
                    <div class="row">
                        <div class="col-md">
                            Temperatura:
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md">
                            <input style="height:48px"
                                   type="number"
                                   step="0.01"
                                   id="Temperature"
                                   name="Temperature" /><br /><br />
                        </div>
                    </div>
                </div>

                <div class="col-md">
                    <div class="row">
                        <div class="col-md">
                            <span>Naprężenie ścinające:</span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md">
                            <input style="height:48px"
                                   type="number"
                                   step="0.01"
                                   id="ShearStress"
                                   name="ShearStress" /><br /><br />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <br>
            </div>

            <div style="text-align: center">
                <div class="row">
                    <div class="col-md">
                        <button @click="submitInputs()">Oblicz</button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md">
                        <p>{{ displayedValue }}</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from "axios";

    export default {
        name: "Home",
        first: 0,
        second: 0,
        temperatureValue: 0,
        shearStressValue: 0,
        data() {
            return {
                file: "",
                displayedValue: "",
                people: [
                    { key: 1, name: "AZ91" },
                    { key: 2, name: "E21" },
                    { key: 3, name: "WE43B" },
                ],
                selectedPerson: "AZ91",
            };
        },
        methods: {
            submitInputs() {
                var temperatureValue = document.querySelector("input[name=Temperature]").value;
                var shearStressValue = document.querySelector("input[name=ShearStress]").value;
                var selectedModelValue = this.selectedPerson;

                temperatureValue = parseFloat(temperatureValue);
                shearStressValue = parseFloat(shearStressValue);

                axios
                    .post(
                        "api/Calculate",
                        {
                            Temperature: temperatureValue,
                            ShearStress: shearStressValue,
                            WhichModel: selectedModelValue,
                        },
                        {
                            headers: {
                                "Content-Type": "application/json",
                            },
                        }
                    )
                    .then(response => {
                        console.log(response);

                        axios.get("api/Get").then((response) => {
                            const val = response.data;
                            this.displayedValue = "Przewidywana lepkość dynamiczna: " + val;
                            console.log(val);
                            console.log("displayedValueSuccess");
                        })
                    })
                    .catch(function () {
                        console.log("FAILURE!!");
                    });
            },
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped></style>
