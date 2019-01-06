/*
Copyright 2010 Google Inc

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System.Reflection;
using System.Runtime.CompilerServices;

// Information about this assembly is defined by the following attributes. 
// Change them to the values specific to your project.

[assembly: AssemblyTitle("Google.Apis")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Google Inc")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("Copyright © Google Inc 2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

#if SIGNED
[assembly: InternalsVisibleTo("Google.Apis.Tests,PublicKey=" +
    "00240000048000009400000006020000002400005253413100040000010001003d69fa08add2ea" + 
    "7341cc102edb2f3a59bb49e7f7c8bf1bd96d494013c194f4d80ee30278f20e08a0b7cb863d6522" +
    "d8c1c0071dd36748297deefeb99e899e6a80b9ddc490e88ea566d2f7d4f442211f7beb6b2387fb" +
    "435bfaa3ecfe7afc0184cc46f80a5866e6bb8eb73f64a3964ed82f6a5036b91b1ac93e1f44508b" +
    "65e51fce")]
#else
[assembly: InternalsVisibleTo("Google.Apis.Tests")]
#endif

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.
[assembly: AssemblyVersion("1.10.0.*")]

// The following attributes are used to specify the signing key for the assembly, 
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]
