<template>
  <div class="container">
    <div class="large-12 medium-12 small-12 cell">
      <div class="row">
        <div class="col-md">
          <div class="row">
            FirstInput
          </div>
          <div class="row">
            <input type="text" id="firstInput" name="firstInput" /><br /><br />
          </div>
        </div>
        <div class="col-md">
          <div class="row">
            SecondInput
          </div>
          <div class="row">
            <input
              type="text"
              id="secondInput"
              name="secondInput"
            /><br /><br />
          </div>
        </div>
        <div class="col-md">
          <div class="row">
            ThirdInput
          </div>
          <div class="row">
            <input type="text" id="thirdInput" name="thirdInput" /><br /><br />
          </div>
        </div>
      </div>

      <div style="text-align: center" class="row">
        <div class="col-md">
          <button @click="submitInputs()">Submit</button>
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
  data() {
    return {
      file: "",
    };
  },

  methods: {
    handleFileUpload() {
      console.log("start handle");
      this.file = this.$refs.myFiles.files[0];
      console.log(this.file);
      console.log("end handle");
    },

    submitInputs() {
      var first = document.getElementById("firstInput").value;
      var second = document.getElementById("secondInput").value;
      var third = document.getElementById("thirdInput").value;

      axios
        .post(
          "api/Calculate",
         { a: first, b: second, c: third },
          {
            headers: {
              "Content-Type": "application/json",
            },
          }
        )
        .then(function() {
          console.log("SUCCESS!!");
        })
        .catch(function() {
          console.log("FAILURE!!");
        });
    },

    submitFile() {
      let formData = new FormData();
      console.log("appending");
      console.log(this.file);
      formData.append("file", this.file, "uploadedFile");

      axios
        .post("api/UploadFile", formData, {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        })
        .then(function() {
          console.log("SUCCESS!!");
        })
        .catch(function() {
          console.log("FAILURE!!");
        });
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped></style>
