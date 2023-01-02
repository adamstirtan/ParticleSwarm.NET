﻿using ParticleSwarmSharp;
using ParticleSwarmSharp.Fitness;
using ParticleSwarmSharp.Particles;
using ParticleSwarmSharp.Populations;
using ParticleSwarmSharp.Randomization;
using ParticleSwarmSharp.Termination;

IRandomization random = new BasicRandomization();

int populationSize = 25;
int dimensions = 1;
double minX = -10.0;
double maxX = 10.0;

List<ClassicParticle> particles = new();

for (int i = 0; i < populationSize; i++)
{
    ClassicParticle particle = new(dimensions);

    particle.Position = random.GetDoubles(dimensions, minX, maxX);
    particle.Velocity = random.GetDoubles(dimensions, 0, 1);

    particles.Add(particle);
}

IPopulation population = new Population(particles);

IFitnessFunction fitness = new FuncFitness(candidate =>
{
    double x = candidate.Position[0];

    return Math.Pow(x, 2);
});

IParticleSwarm pso = new ParticleSwarm(
    population,
    fitness,
    new GenerationCountTermination(100));

pso.GenerationComplete += (s, e) =>
{
    Console.WriteLine(e.ToString());
};

pso.TerminationCriteriaReached += (s, e) =>
{
    Console.WriteLine(e.ToString());
};

pso.Stopped += (s, e) =>
{
    Console.WriteLine(e.ToString());
};

pso.Start();