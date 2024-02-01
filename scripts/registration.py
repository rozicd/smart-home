import csv
import faker

fake = faker.Faker()

# Number of records to generate
num_records = 1000

# Header for the CSV file
header = ['Name', 'Email', 'Password']

# Generate data and write to CSV
with open('user_data.csv', 'w', newline='') as csvfile:
    csv_writer = csv.writer(csvfile)
    csv_writer.writerow(header)

    for _ in range(num_records):
        name = fake.name()
        email = fake.email()
        password = fake.password()

        csv_writer.writerow([name, email, password])