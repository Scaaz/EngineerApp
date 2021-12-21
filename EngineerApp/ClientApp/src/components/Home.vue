<template>
    <div class="container">
        <div class="large-12 medium-12 small-12 cell">
            <div class="row">
                <div class="col-md">
                    <div class="row">
                        Stop:
                    </div>
                    <div class="row">
                        <div>
                            <select v-model="selectedPerson">
                                <option v-for="person in people" :key="person.key">{{person.name}}</option>
                            </select>
                        </div>
                    </div>
                </div>

                <div class="col-md">
                    <div class="row">
                        Temperatura:
                    </div>
                    <div class="row">
                        <input type="number"
                               step="0.01"
                               id="Temperature"
                               name="Temperature" /><br /><br />
                    </div>
                </div>

                <div class="col-md">
                    <div class="row">
                        <span>Naprężenie ścinające:</span>
                    </div>
                    <div class="row">
                        <input type="number"
                               step="0.01"
                               id="ShearStress"
                               name="ShearStress" /><br /><br />
                    </div>
                </div>
            </div>

            <div style="text-align: center">
                <div class="row">
                    <div class="col-md">
                        <button @click="submitInputs()">Oblicz</button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md">
                        <p>Lepkość dynamiczna: {{ displayedValue }}</p>
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
        third: 0,
        fourth: 0,
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
        watch() {
            this.getDisplayValue();
            console.log("created");
        },
        methods: {
            submitInputs() {
                var third = document.querySelector("input[name=Temperature]").value;
                var fourth = document.querySelector("input[name=ShearStress]").value;

                third = parseFloat(third);
                fourth = parseFloat(fourth);

                axios
                    .post(
                        "api/Calculate",
                        {
                            Temperature: third,
                            ShearStress: fourth,
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
                            this.displayedValue = val;
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
