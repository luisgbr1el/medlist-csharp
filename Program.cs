using System;
using MedTest.Entities;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace MedTest {
    class Program {
        static void Main(string[] args) {

            try {

                Console.Write("How many doctors do you want to register? ");
                int n = int.Parse(Console.ReadLine());

                List<Doctor> doctors = new List<Doctor>();


                for (int i = 1; i <= n; i++) {
                    Console.WriteLine();
                    Console.WriteLine($"[DOCTOR #{i}]");
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Area: ");
                    string area = Console.ReadLine();
                    Console.Write("Situation (1 - Active, 2 - Stand-by, 3 - Retired): ");
                    string na = Console.ReadLine();

                    string situation = null;
                    switch (na) {
                        case "1":
                            situation = "ACTIVE";
                            break;
                        case "2":
                            situation = "STAND-BY";
                            break;
                        case "3":
                            situation = "RETIRED";
                            break;
                        default:
                            situation = "UNKNOWN";
                            break;
                    }

                    Console.Write("City: ");
                    string city = Console.ReadLine();
                    Console.Write("State: ");
                    string state = Console.ReadLine();
                    Console.Write("Age: ");
                    int age = int.Parse(Console.ReadLine());

                    doctors.Add(new Doctor(name, area, situation, city, state, age));
                }

                Console.WriteLine();
                Console.WriteLine("[REGISTERED DOCTORS]");
                foreach (Doctor doctor in doctors) {
                    Console.WriteLine(doctor);
                }

                Console.WriteLine();
                Console.Write("Do you want to save this in a .html file? (y/n) ");
                string answer = Console.ReadLine();

                if (answer == "y" || answer == "Y") {
                    string path = "C:\\temp";
                    string fileName = "\\summaryDoctors";
                    DateTime datetime = DateTime.Now;

                    string fullName = path + fileName + "_" + datetime.ToString("ddMMyyyy_HHmmss") + ".html";

                    using (StreamWriter sw = new StreamWriter(fullName)) {
                        sw.WriteLine("<head>");
                        sw.WriteLine($" <title>summaryDoctors_{datetime.ToString("ddMMyyyy_HHmmss")}</title>");
                        sw.WriteLine("  <style type='text/css' media='print'>h1, body, table, div#head { color: black;}table, th, td { border: 1px solid black !important;} button { display: none !important;}</style>");
                        sw.WriteLine("  <style>");
                        sw.WriteLine("      @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@300&display=swap');");
                        sw.WriteLine("      body { font-family: 'Poppins', sans-serif; font-size: 16pt; color: rgb(214, 214, 214); margin: 0; background-color: rgb(31, 31, 31);}");
                        sw.WriteLine("      table, th, td { border: 1px solid rgb(214, 214, 214); border-collapse: collapse; padding: 7px; }");
                        sw.WriteLine("      div#head { margin: 0; padding: 1px; background-color: rgb(41, 41, 41); margin-bottom: 30px; color: rgb(214, 214, 214);}");    
                        sw.WriteLine("      button { font-weight: bolder; transition: 0.1s; padding: 10px; border-radius: 5px; background-color: rgb(41, 41, 41); color: rgb(214, 214, 214); border: none; font-size: 10pt; font-family: 'Poppins', sans-serif; cursor: pointer;}");    
                        sw.WriteLine("      button:hover { background-color: rgb(36, 35, 35); transition: 0.1s;}");    
                        sw.WriteLine("  </style>");
                        sw.WriteLine("</head>");
                        sw.WriteLine("<center>");
                        sw.WriteLine("  <div id='head'>");
                        sw.WriteLine("      <h1 style='font-size: 18pt; '>Summary doctors</h1>");
                        sw.WriteLine("  </div>");
                        sw.WriteLine("  <table>");
                        sw.WriteLine("      <tr>");
                        sw.WriteLine("          <th>NAME</th>");
                        sw.WriteLine("          <th>AREA</th>");
                        sw.WriteLine("          <th>SITUATION</th>");
                        sw.WriteLine("          <th>LOCALIZATION</th>");
                        sw.WriteLine("          <th>AGE</th>");
                        sw.WriteLine("      </tr>");
                        foreach (Doctor doctor in doctors) {
                            //sw.WriteLine(doctor);
                            sw.WriteLine("      <tr>");
                            sw.WriteLine($"         <td>{doctor.Name}</td>");
                            sw.WriteLine($"         <td>{doctor.Area}</td>");
                            sw.WriteLine($"         <td>{doctor.Situation}</td>");
                            sw.WriteLine($"         <td>{doctor.City} - {doctor.State}</td>");
                            sw.WriteLine($"         <td>{doctor.Age}</td>");
                            sw.WriteLine("      </tr>");
                        }
                        sw.WriteLine("  </table>");
                        sw.WriteLine("  <br>");
                        sw.WriteLine("  <button id='print' onclick='window.print(); return false; '/>Print page or Save PDF</button>");
                        sw.WriteLine("</center>");
                        Console.WriteLine();
                        Console.WriteLine($"File saved in '{fullName}'!");
                        Console.WriteLine("Opening file...");
                    }

                    var p = new Process();
                    p.StartInfo = new ProcessStartInfo(fullName) {
                        UseShellExecute = true
                    };
                    p.Start();

                }
                else {
                    Console.WriteLine();
                    Console.WriteLine("Right, stopping...");
                    return;
                }
            }
            catch (ArgumentException e) {
                Console.WriteLine("Error! " + e.Message);
            }
            catch (FormatException e) {
                Console.WriteLine("Error! " + e.Message);
            }
        }
    }
}
