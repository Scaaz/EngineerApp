<template>
  <div class="container">
    <div class="large-12 medium-12 small-12 cell">
      <div class="row">
        <div class="col-md">
          <div class="row">
            measPts
          </div>
          <div class="row">
            <input
              type="number"
              step="0.01"
              id="meas-pts"
              name="meas-pts"
            /><br /><br />
          </div>
        </div>

        <div class="col-md">
          <div class="row">
            gap
          </div>
          <div class="row">
            <input type="number" step="0.01" id="gap" name="gap" /><br /><br />
          </div>
        </div>

        <div class="col-md">
          <div class="row">
            shearRate
          </div>
          <div class="row">
            <input
              type="number"
              step="0.01"
              id="shear-rate"
              name="shear-rate"
            /><br /><br />
          </div>
        </div>

        <div class="col-md">
          <div class="row">
            ShearStress
          </div>
          <div class="row">
            <input
              type="number"
              step="0.01"
              id="shear-stress"
              name="shear-stress"
            /><br /><br />
          </div>
        </div>
      </div>

      <div style="text-align: center" class="row">
        <div class="col-md">
          <button @click="submitInputs()">Submit</button>
          <button @click="wynik()">wynik</button>
        </div>
        <div class="row">
          <p>wynik: {{ displayedValue }}</p>
        </div>
      </div>
      <!-- <label
        >File
        <input
          type="file"
          id="file"
          ref="myFiles"
          @change="handleFileUpload()"
        />
      </label>
      <button @click="submitFile()">Submit</button> -->
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
    // handleFileUpload() {
    //   console.log("start handle");
    //   this.file = this.$refs.myFiles.files[0];
    //   console.log(this.file);
    //   console.log("end handle");
    // },

    getDisplayValue() {
      axios.get("api/Get").then((response) => {
        const val = response.data;
        this.displayedValue = val;
        console.log(val);
        console.log("displayedValueSuccess");
      });
    },
    wynik() {
      this.getDisplayValue();
    },
    submitInputs() {
      var first = document.querySelector("input[name=meas-pts]").value;
      var second = document.querySelector("input[name=meas-pts]").value;
      var third = document.querySelector("input[name=shear-rate]").value;
      var fourth = document.querySelector("input[name=shear-stress]").value;
      
      first = parseFloat(first);
      second = parseFloat(second);
      third = parseFloat(third);
      fourth = parseFloat(fourth);

      axios
        .post(
          "api/Calculate",
          {
            MeasPts: first,
            Gap: second,
            ShearRate: third,
            ShearStress: fourth,
          },
          {
            headers: {
              "Content-Type": "application/json",
            },
          }
        )
        .then(function() {
          console.log("SUCCESS");
        })
        .catch(function() {
          console.log("FAILURE!!");
        });
    },

    //   submitFile() {
    //     let formData = new FormData();
    //     console.log("appending");
    //     console.log(this.file);
    //     formData.append("file", this.file, "uploadedFile");

    //     axios
    //       .post("api/UploadFile", formData, {
    //         headers: {
    //           "Content-Type": "multipart/form-data",
    //         },
    //       })
    //       .then(function() {
    //         console.log("SUCCESS!!");
    //       })
    //       .catch(function() {
    //         console.log("FAILURE!!");
    //       });
    //   },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped></style>
