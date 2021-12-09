<template>
    <div class="container">
        <div class="large-12 medium-12 small-12 cell">
            <div class="row">
                <div class="col-md">
                    <div class="row">
                        Speed
                    </div>
                    <div class="row">
                        <input type="number"
                               step="0.01"
                               id="Speed"
                               name="Speed" /><br /><br />
                    </div>
                </div>

                <div class="col-md">
                    <div class="row">
                        Torque
                    </div>
                    <div class="row">
                        <input type="number" step="0.01" id="Torque" name="Torque" /><br /><br />
                    </div>
                </div>

                <div class="col-md">
                    <div class="row">
                        Temperature
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
                        NormalForce
                    </div>
                    <div class="row">
                        <input type="number"
                               step="0.01"
                               id="NormalForce"
                               name="NormalForce" /><br /><br />
                    </div>
                </div>
            </div>

            <div style="text-align: center">
                <div class="row">
                    <div class="col-md">
                        <button @click="submitInputs()">Submit</button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md">
                        <p>wynik: {{ displayedValue }}</p>
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
            };
        },
        watch() {
            this.getDisplayValue();
            console.log("created");
        },
        methods: {
            submitInputs() {
                var first = document.querySelector("input[name=Speed]").value;
                var second = document.querySelector("input[name=Torque]").value;
                var third = document.querySelector("input[name=Temperature]").value;
                var fourth = document.querySelector("input[name=NormalForce]").value;

                first = parseFloat(first);
                second = parseFloat(second);
                third = parseFloat(third);
                fourth = parseFloat(fourth);

                axios
                    .post(
                        "api/Calculate",
                        {
                            Speed: first,
                            Torque: second,
                            Temperature: third,
                            NormalForce: fourth,
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
